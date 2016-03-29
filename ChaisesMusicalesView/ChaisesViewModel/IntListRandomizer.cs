﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
//test git
namespace ChaisesMusicales
{
    internal class IntListRandomizer<T>:IListRandomizer<T,predicate>
    {
        private int count;

        public IntListRandomizer(int count)
        {
            this.count = count;
        }

        public List<T> randomizeList(List<T> list,List<IPredicateOnList<predicate>> predicates)
        {
            List<int> mixIntegers = mixNIntegers(predicates);
            List<T> cvm = new List<T>();
            foreach (int i in mixIntegers)
            {
                cvm.Add(list[i]);

            }

            return cvm;

        }

        private List<int> mixNIntegers(List<IPredicateOnList<predicate>> predicates)
        {
            List<int> mixIntegers = new List<int>();


            Random rnd = new Random();

            int v;

            for (int i = 0; i < count; i++)
            {
                ISet<int> vtab = new SortedSet<int>();
                do
                {
                    if (vtab.Count == count) { mixIntegers.Clear(); i = 0; } 
                    v = rnd.Next(0, count);
                    vtab.Add(v);
                }
                //TO CHANGE
                while (v == i || mixIntegers.Contains(v) || !predicates.TrueForAll(p => p.RealPredicate(mixIntegers.Concat(new List<int>() { v }).ToList())));

                Console.Out.WriteLine(v);

                mixIntegers.Add(v);
            }

            return mixIntegers;


        }


    }
    }