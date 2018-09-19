using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacionDeServicios.Response
{
    public class ResponseBase
    {
        private bool isValid;

        public bool IsValid
        {
            get { return isValid; }
            set { isValid = value; }
        }

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }


    }
}