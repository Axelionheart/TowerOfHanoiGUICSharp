using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerOfHanoiUI
{
    class Disc
    {
        private int m_discSize;
        private int m_StartingPointToMoveDisc;
        private int m_discWidth;

        private Direction m_direction;

        public Disc(int discSize,Direction direction,int currentPole,int discWidth)
        {
            this.m_discSize = discSize;
            this.m_direction = direction;
            this.m_StartingPointToMoveDisc = currentPole;
            this.m_discWidth = discWidth;
        }

        public int GetDiscSize()
        {
            return this.m_discSize;
        }

        public Direction GetDiscDirection()
        {
            return this.m_direction;
        }

        public int GetStartingPosition()
        {
            return this.m_StartingPointToMoveDisc;
        }

        public void ChangeDiscToPole(int newPoleReference)
        {
            this.m_StartingPointToMoveDisc = newPoleReference;
        }

        public void DrawDisc(TowerOfHanoiForm myForm,int x,int y)
        {
            myForm.DrawDisc(x,y,m_discWidth);
        }

        public void ReverseDirection()
        {
            this.m_direction = (this.m_direction == Direction.CLOCKWISE) ? Direction.ANTI_CLOCKWISE : Direction.CLOCKWISE;
        }

        public bool CompareDiscs(Disc checkingDisc)
        {
            return (m_discSize > checkingDisc.GetDiscSize()) || this == null;
        }

        public void UpdateWidth(int width,int discNumber)
        {
            this.m_discWidth = width - (discNumber - m_discSize + 1);
        }
    }
}
