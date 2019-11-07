using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerOfHanoiUI
{
    class Controller
    {
        private const int SOURCE_POLE = 0;
        private const int AUX_POLE = 1;
        private const int DEST_POLE = 2;

        private int m_sourcePoleIndex = 0;
        private int m_auxiliaryPoleIndex = 1;
        private int m_destinationPoleIndex = 2;

        private int m_subTowerDivision;
        private int m_numberOfSubdivision;
        private int m_numberOfDiscs;
        private bool m_movingSubTower = false;

        private Pole[] m_polesInUse = new Pole[3];
        private Pole[] m_poles;        

        private States m_state;
        private BoardState m_boardState;

        public void InitializePoles(int numberOfPoles)
        {
            m_poles = new Pole[numberOfPoles];

            for (int i = 0; i < numberOfPoles; i++)
            {
                m_poles[i] = new Pole(i);
            }
        }
        void SetPolesInUse()
        {
            m_polesInUse[SOURCE_POLE] = m_poles[m_sourcePoleIndex];
            m_polesInUse[AUX_POLE] = m_poles[m_auxiliaryPoleIndex];
            m_polesInUse[DEST_POLE] = m_poles[m_destinationPoleIndex];
        }

        public void SetMaximumAmount(int numberOfDiscs)
        {
            m_poles[m_poles.Length - 1].SetPoleCapacity(numberOfDiscs);
        }

        public void InitializeDiscs(int numberOfDiscs,int discWidth)
        {
            this.m_numberOfDiscs = numberOfDiscs;
            m_poles[SOURCE_POLE].InitializeDiscsInFirstPole(numberOfDiscs,discWidth);
            SetPolesInUse();

            this.m_subTowerDivision = m_numberOfDiscs / (m_poles.Length - 2);
            this.m_numberOfSubdivision = m_subTowerDivision;

            if (m_numberOfDiscs % (m_poles.Length - 2) != 0)
            {
                m_subTowerDivision++;
                m_numberOfSubdivision++;
            }
        }

        public void UpdateWidth(int width, int discNumber)
        {
            foreach (Pole pole in m_poles)
            {
                pole.UpdateDiscWidth(width,discNumber);
            }
        }

        void ReverseDiscDirectionOnPole(Pole pole,int divisions)
        {
            pole.ReverseDiscsDirection(divisions);
        }

        public void InitiateAlgorithm()
        {
            if (m_poles.Length == 3)
            {
                ThreePolesAlgorithm();
            }
            else
            {
                MorePolesAlgorithm();
            }
        }

        void ThreePolesAlgorithm()
        {
            MoveDisc();
        }

        void MorePolesAlgorithm()
        {
            if(m_boardState == BoardState.movingForward)
            {
               MoveSubTowerForward();
            }
            else
            {
               MoveSubTowerBackward();
            }
        }

        void ChangePoleReference(Pole[] poles)
        {
            for(int i = 0; i < poles.Length; i++)
            {
                poles[i].ChangePoleReference(i); 
            }
        }

        void MoveSubTowerBackward()
        {
            if (!m_movingSubTower)
            {
                ReverseDiscDirectionOnPole(m_polesInUse[AUX_POLE],m_subTowerDivision);
                ChangePoleReference(m_polesInUse);
                m_movingSubTower = true;
            }

            if (!(m_polesInUse[AUX_POLE].IsEmpty() && m_polesInUse[DEST_POLE].GetDiscCount() == m_subTowerDivision))
            {
                MoveDisc();
            }
            else
            {
                m_auxiliaryPoleIndex--;
                SetPolesInUse();
                m_state = States.movingSmallPiece;
                m_subTowerDivision += m_numberOfSubdivision;
                m_movingSubTower = false;
            }
        }

        void MoveSubTowerForward()
        {
            if (!m_movingSubTower)
            {
                CheckSubtowerDirection();
                m_movingSubTower = true;
            }

            if (m_movingSubTower)
            {          

                if (m_polesInUse[DEST_POLE].GetDiscCount() != m_subTowerDivision)
                {
                    MoveDisc();
                }
                else if(m_poles[SOURCE_POLE].GetDiscCount() == 0)
                {
                    if(m_poles[m_poles.Length - 1].GetDiscCount() == 0)
                    {
                        m_subTowerDivision = m_polesInUse[DEST_POLE].GetDiscCount();
                        ChangeStateToMovingBackward();
                        m_auxiliaryPoleIndex = m_destinationPoleIndex;
                        m_destinationPoleIndex = m_poles.Length - 1;
                        SetPolesInUse();
                    }
                    else
                    {
                        m_subTowerDivision += m_numberOfSubdivision;
                        m_auxiliaryPoleIndex = m_destinationPoleIndex - 1;
                        ChangeStateToMovingBackward();
                        SetPolesInUse();
                    }                    
                }
                else
                {
                    if(m_polesInUse[SOURCE_POLE].GetDiscCount() < m_subTowerDivision)
                    {
                        m_subTowerDivision = m_polesInUse[SOURCE_POLE].GetDiscCount();
                        ReverseDiscDirectionOnPole(m_polesInUse[SOURCE_POLE],m_subTowerDivision);
                    }

                    m_state = States.movingSmallPiece;
                    m_destinationPoleIndex++;
                    SetPolesInUse();
                    m_movingSubTower = false;                    
                }
            }           
        }

        void ChangeStateToMovingBackward()
        {
            m_boardState = BoardState.movingBackward;
            m_state = States.movingSmallPiece;
            m_movingSubTower = false;
        }

        void CheckSubtowerDirection()
        {
            if (m_polesInUse[SOURCE_POLE].GetDiscDirection() == Direction.CLOCKWISE && m_subTowerDivision % 2 == 1)
            {
                ReverseDiscDirectionOnPole(m_polesInUse[SOURCE_POLE], m_subTowerDivision);
            }

            if (m_polesInUse[SOURCE_POLE].GetDiscDirection() == Direction.ANTI_CLOCKWISE && m_subTowerDivision % 2 == 0)
            {
                ReverseDiscDirectionOnPole(m_polesInUse[SOURCE_POLE], m_subTowerDivision);
            }
        }
        public void MoveDisc()
        {               
            if (this.m_state == States.movingSmallPiece)
            {
                MoveSmallDisc();
                this.m_state = States.movingBigPiece;
            }
            else
            {
                MoveBigDisc();
                this.m_state = States.movingSmallPiece;                
            }            
        }
        
        public bool IsPuzzleComplete()
        {
            return m_poles[m_poles.Length - 1].IsFull();
        }
        Pole FindPoleWithSmallestDisc()
        {
            Pole poleFound = null;
            int smallestDiscNumber = m_numberOfDiscs;

            foreach(Pole pole in m_polesInUse)
            {
                if (pole.IsEmpty())
                {
                    continue;
                }
                else
                {
                    Disc discOnPole = pole.PeekDisc();

                    if(discOnPole == null)
                    {
                        continue;
                    }

                    if (discOnPole.GetDiscSize() <= smallestDiscNumber)
                    {
                        smallestDiscNumber = discOnPole.GetDiscSize();
                        poleFound = pole;
                    }
                }
            }

            return poleFound;
        }
        Pole FindPoleWithBiggestDisc(int reducer)
        {
            int biggestNumber = m_numberOfDiscs - reducer;
            Pole poleFound = null;

            foreach (Pole pole in m_polesInUse)
            {
                if (pole.IsEmpty())
                {
                    continue;
                }

                Disc discOnPole = pole.PeekDisc();

                if (discOnPole == null)
                {
                    continue;
                }

                if (discOnPole.GetDiscSize() == biggestNumber)
                {
                    biggestNumber = discOnPole.GetDiscSize();
                    poleFound = pole;
                    break;
                }
            }

            return poleFound;
        }       

        void MoveSmallDisc()
        {
            Pole poleWithSmallDisc = FindPoleWithSmallestDisc();
            Disc smallestDisc = poleWithSmallDisc.PopDisc();

            if (smallestDisc.GetDiscDirection() == Direction.ANTI_CLOCKWISE)
            {
                MoveAntiClockWise(smallestDisc);
            }
            else
            {
                MoveClockWise(smallestDisc);
            }                
        }
        void MoveBigDisc()
        {
            int reducer = 0;
            bool biggestPieceMoved = false;
            Pole poleWithBiggestDisc = FindPoleWithBiggestDisc(reducer);

            do
            {
                while(poleWithBiggestDisc == null)
                {
                    reducer++;
                    poleWithBiggestDisc = FindPoleWithBiggestDisc(reducer);
                }

                Disc discFound = poleWithBiggestDisc.PopDisc();

                if (discFound.GetDiscDirection() == Direction.ANTI_CLOCKWISE)
                {
                    if (MoveAntiClockWise(discFound))
                        break;
                }
                else
                {
                    if(MoveClockWise(discFound))
                       break;
                }

                reducer++;
                int startingIndex = poleWithBiggestDisc.GetPoleReference();
                poleWithBiggestDisc.PushDisc(discFound,startingIndex);
                poleWithBiggestDisc = FindPoleWithBiggestDisc(reducer);

            } while (!biggestPieceMoved);
            
        }

        bool MoveAntiClockWise(Disc discFound)
        {
            for (int i = discFound.GetStartingPosition() - 1; i >= 0; i--)
            {
                if (m_polesInUse[i].PoleIsAvailableForDisc(discFound))
                {
                    m_polesInUse[i].PushDisc(discFound,i);
                    return true;
                }
            }

            for(int i = m_polesInUse.Length - 1;i > discFound.GetStartingPosition(); i--)
            {
                if (m_polesInUse[i].PoleIsAvailableForDisc(discFound))
                {
                    m_polesInUse[i].PushDisc(discFound,i);
                    return true;
                }
            }

            return false;
        }

        bool MoveClockWise(Disc discFound)
        {
            for (int i = discFound.GetStartingPosition() + 1; i < m_polesInUse.Length; i++)
            {
                if (m_polesInUse[i].PoleIsAvailableForDisc(discFound))
                {
                    m_polesInUse[i].PushDisc(discFound,i);
                    return true;
                }
            }

            for (int i = 0; i < discFound.GetStartingPosition(); i++)
            {
                if (m_polesInUse[i].PoleIsAvailableForDisc(discFound))
                {
                    m_polesInUse[i].PushDisc(discFound,i);
                    return true;
                }
            }

            return false;
        }      
        
        public Pole[] GetPoles()
        {
            return this.m_poles;
        }
    }
}
