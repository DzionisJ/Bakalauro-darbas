using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Model
{
    class PasswordGenDataModel
    {

        private string _GenPass;
        private int _GenPassLength;

        public PasswordGenDataModel()
        {
        }

        public PasswordGenDataModel(string GeneratedPass, int GenPasslength)
        {
            this._GenPass = GeneratedPass;
            this._GenPassLength = GenPasslength;
        }

        public string GenPass
        {
            get { return _GenPass; }
            set { _GenPass = value; }
        }

        public int GenPassLength
        {
            get { return _GenPassLength; }
            set { _GenPassLength = value; }
        }


    }
}
