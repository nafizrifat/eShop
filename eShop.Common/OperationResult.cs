﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Common
{
    /// <summary>
    /// Provides a success flag and message 
    /// useful as a method return type.
    /// </summary>
    public class OperationResult
    {
        public OperationResult()
        {
        }

        public OperationResult(bool success, string message)
            : this()
        {
            this.Success = success;
            this.Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
