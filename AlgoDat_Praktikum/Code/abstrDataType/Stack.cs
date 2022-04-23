using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDat_Praktikum.Code.abstrDataType
{
    abstract class Stack : Helper
    {
        /// <summary>
        /// place elem on the stack
        /// </summary>
        /// <param name="elem"></param>
        public abstract void push(int elem);

        /// <summary>
        /// delete the top elem
        /// </summary>
        /// <returns></returns>
        public abstract int pop();

        /// <summary>
        /// return value of the top elem
        /// </summary>
        /// <returns></returns>
        public abstract int top();
    }
}
