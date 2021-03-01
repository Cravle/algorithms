﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Model
{
    public class QueueItem<T>
    {
        public T Data { get; set; }
        public QueueItem<T> Next{get; set;}

        public QueueItem(T data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}