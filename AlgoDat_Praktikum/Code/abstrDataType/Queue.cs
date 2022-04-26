using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDat_Praktikum.Code.abstrDataType
{
    abstract class Queue : Helper
    {
        /// <summary>
        /// append elem at the end of the queue
        /// </summary>
        /// <param name="elem"></param>
        public abstract void put(int elem);

        /// <summary>
        /// return the value of the first elem
        /// </summary>
        /// <returns></returns>
        public abstract int get();

        /// <summary>
        /// delete the first elem in the queue
        /// </summary>
        public abstract void delete();
    }
}
