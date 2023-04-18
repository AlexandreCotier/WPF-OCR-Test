using EasyHunt.StructureClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHunt.HMI.Main
{
    public class MainModel : Model
    {
        #region MyProp

        private string holderMyProp;

        public string MyProp
        {

            get { return holderMyProp; }
            set
            {
                if(holderMyProp != value)
                {
                    holderMyProp = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region ScreenCommand

        private Command holderScreenCommand;

        public Command ScreenCommand
        {

            get { return holderScreenCommand; }
            set
            {
                if (holderScreenCommand != value)
                {
                    holderScreenCommand = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion
    }
}
