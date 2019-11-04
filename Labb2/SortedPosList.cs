﻿using System;
using System.Collections.Generic;

namespace Labb2
{
    public class SortedPosList
    {
        //properties
        List<Position> positionList { get; set; }


        //Constructor
        public SortedPosList() => positionList = new List<Position>();

        //Methods
        public int Count()
        {
            return positionList.Count;
        }

        public void Add(Position pos)
        {
            if (positionList.Count <= 0)
            {
                positionList.Add(pos);
            }
            else
            {
                for (int i = 0; i < positionList.Count; i++)
                {
                    if (positionList[i].Length() > pos.Length()) //17 > new 13
                    {
                        positionList.Insert(i, pos);
                        return;
                    } 
                    
                }
                 positionList.Add(pos);
            }
        }

        public bool Remove(Position pos)
        {
            bool didRemove = false;

            for(int i = 0; i < positionList.Count; i++)
            {
                if (positionList[i].Equals(pos))
                {
                    positionList.RemoveAt(i);
                    didRemove = true;
                }
            }

            return didRemove;
        }

        //TODO: fix
        public SortedPosList Clone()
        {
            SortedPosList copy = new SortedPosList();

            foreach (Position position in positionList)
            {
                Position p = position.Clone();
                copy.Add(p);
            }
            return copy;
        }

        public SortedPosList CircleContent(Position centerPos, double radius)
        {
            SortedPosList copy = this.Clone();

            for (int i = 0; i < copy.positionList.Count; i++)
            {
                Position position = copy.positionList[i];

                bool isInside = (position.X - centerPos.X) * (position.X - centerPos.X) + (position.Y - centerPos.Y) * (position.Y - centerPos.Y) < radius * radius;

                //TODO: FIXME 
                if (!isInside)
                {
                    copy.positionList.Remove(position);
                }
            }

            return copy;
        }

        //Overload
        public override string ToString()
        {
            return string.Join(", ", positionList);
        }

        //Static methods
        public static SortedPosList operator +(SortedPosList sp1, SortedPosList sp2)
        {
            SortedPosList copiedList = sp1.Clone();
            for (int i = 0; i < sp2.Count(); i++) {
                copiedList.Add(sp2.positionList[i]);
            }
            return copiedList;
        }
    }
}