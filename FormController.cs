using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerOfHanoiUI
{
    class FormController : IFormController
    {
        TowerOfHanoiForm m_form;
        Controller m_towerController;

        public FormController(TowerOfHanoiForm form, Controller controller)
        {
            this.m_form = form;
            this.m_towerController = controller;
        }

        public void DrawBoardOnForm()
        {
            m_form.DrawBoard();
        }

        public void InitiateSolution()
        {
            m_towerController.InitiateAlgorithm();
        }
    }
}
