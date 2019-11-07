using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerOfHanoiUI
{
    class Pole
    {
        private readonly int STARTING_POLE = 0;
        private const int DISC_HEIGTH = 10;
        private Stack<Disc> m_poleDiscs = new Stack<Disc>();
        private int m_poleCapacity;
        private int m_poleReference;

        public Pole( int poleReference)
        {
            this.m_poleReference = poleReference;
        }
        public void InitializeDiscsInFirstPole(int numberOfDiscs, int discWidth)
        {
            for (int i = numberOfDiscs; i > 0; i--)
            {
                if (numberOfDiscs % 2 == 0)
                {
                    if (i % 2 == 0)
                        m_poleDiscs.Push(new Disc(i, Direction.ANTI_CLOCKWISE, STARTING_POLE, discWidth));
                    else
                        m_poleDiscs.Push(new Disc(i, Direction.CLOCKWISE, STARTING_POLE, discWidth));
                }
                else
                {
                    if (i % 2 == 0)
                        m_poleDiscs.Push(new Disc(i, Direction.CLOCKWISE, STARTING_POLE, discWidth));
                    else
                        m_poleDiscs.Push(new Disc(i, Direction.ANTI_CLOCKWISE, STARTING_POLE, discWidth));
                }

                discWidth  --;
            }
        }
        public bool IsEmpty()
        {
            return m_poleDiscs.Count == 0;
        }
        public int GetDiscCount()
        {
            return m_poleDiscs.Count;
        }
        public Disc PopDisc()
        {
            if (m_poleDiscs.Count == 0)
                return null;
            return m_poleDiscs.Pop();
        }

        public Disc PeekDisc()
        {
            if (m_poleDiscs.Count == 0)
                return null;
            return m_poleDiscs.Peek();
        }

        public void PushDisc(Disc newDisc,int startingIndex)
        {
            m_poleDiscs.Push(newDisc);
            newDisc.ChangeDiscToPole(startingIndex);
        }

        public bool IsFull()
        {
            return m_poleDiscs.Count() == m_poleCapacity;
        }
        public bool PoleIsAvailableForDisc(Disc checkingDisc)
        {
            if (m_poleDiscs.Count == 0)
            {
                return true;
            }
            else
            {
                Disc poleLastDiscSize = m_poleDiscs.Peek();

                return poleLastDiscSize.CompareDiscs(checkingDisc);
            }
        }

        public void DrawPole(TowerOfHanoiForm form,int x, int y)
        {
            if(m_poleDiscs.Count != 0)
            {
                y = y - m_poleDiscs.Count * DISC_HEIGTH;

                foreach (Disc disc in m_poleDiscs)
                {
                    disc.DrawDisc(form, x, y);
                    y += DISC_HEIGTH;
                }
            }            
        }

        public void SetPoleCapacity(int numberOfDiscs)
        {
            this.m_poleCapacity = numberOfDiscs;
        }

        public void ReverseDiscsDirection(int divisions)
        {
            int count = 0;

            foreach(Disc disc in m_poleDiscs)
            {
                if (count < divisions)
                {
                    disc.ReverseDirection();
                    count++;
                }                    
                else
                    break;
            }
        }
        public Direction GetDiscDirection()
        {
            Disc lastDisc = m_poleDiscs.Peek();
            return lastDisc.GetDiscDirection();
        }
        public void ChangePoleReference(int index)
        {
            foreach(Disc disc in m_poleDiscs)
            {
                disc.ChangeDiscToPole(index);
            }
        }
        public int GetPoleReference()
        {
            return this.m_poleReference;
        }

        public void UpdateDiscWidth(int width,int discNumber)
        {
            foreach(Disc disc in m_poleDiscs)
            {
                disc.UpdateWidth(width,discNumber);
            }
        }
    }
}
