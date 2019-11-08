using System;
using System.Collections.Generic;
using System.IO;

namespace Labb2
{
    public class SortedPosList
    {

        private string path;

        //properties
        List<Position> positionList { get; set; }


        //Constructor
        public SortedPosList() => positionList = new List<Position>();

        public SortedPosList(string filePath)
        {
            path = filePath;
            positionList = new List<Position>();
            Load();
        }

        public void Save(string path)
        {
            string textFormat = string.Join("\n", positionList);
            TextFileHandler.WriteToFile(path, textFormat, true);
        }

        private void Load()
        {
            //read from file
            string[] positionStrings = TextFileHandler.ReadFromFile(path);

            foreach (string positionString in positionStrings)
            {
                if (positionString.Length > 0)
                {
                    //remove parentess
                    string formatedString = positionString.Substring(1);
                    formatedString = formatedString.Remove(formatedString.Length - 1);

                    //splits in to cordinates
                    string[] stringArray = formatedString.Split(',');
                    string xString = stringArray[0];
                    string yString = stringArray[1];

                    int.TryParse(xString, out int x);
                    int.TryParse(yString, out int y);

                    Position position = new Position(x, y);
                    this.Add(position);
                }
            }
        }

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
                    if (positionList[i] > pos)
                    {
                        positionList.Insert(i, pos);
                        if (path != null)
                        {
                            Save(path);
                        }
                        return;
                    }

                }
                positionList.Add(pos);
            }

            //save
            if (path != null)
            {
                Save(path);
            }
        }

        public bool Remove(Position pos)
        {
            bool didRemove = false;

            for (int i = 0; i < positionList.Count; i++)
            {
                if (positionList[i].Equals(pos))
                {
                    positionList.RemoveAt(i);
                    didRemove = true;
                }
            }

            if (path != null)
            {
                Save(path);
            }

            return didRemove;
        }

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
            SortedPosList positionsInsideCircle = new SortedPosList();

            for (int i = 0; i < this.positionList.Count; i++)
            {
                Position position = this.positionList[i];

                bool isInside = (position.X - centerPos.X) * (position.X - centerPos.X) + (position.Y - centerPos.Y) * (position.Y - centerPos.Y) < radius * radius;

                if (isInside)
                {
                    positionsInsideCircle.Add(position.Clone());
                }
            }

            return positionsInsideCircle;
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

        //remove all mutual points
        public static SortedPosList operator *(SortedPosList sp1, SortedPosList sp2)
        {
            //Solution 1
            //SortedPosList copiedList = sp1.Clone();
            //for (int i = 0; i < sp2.Count(); i++)
            //{
            //    Position posToRemove = sp2[i];
            //    copiedList.Remove(posToRemove);
            //}

            //Solution 2
            int i = 0;
            int j = 0;
            SortedPosList newList = new SortedPosList();
            while(i < sp1.Count() && j < sp2.Count())
            {
                //jämför elementen
                if (sp1[i] < sp2[j])
                {
                    newList.Add(sp1[i]);
                    i++;
                }
                else if (sp1[i] > sp2[j])
                {
                    j++;
                } else
                {
                    i++;
                    j++;
                }
            }

            //Solution 2
            return newList;

            //Solution 1
            //return copiedList;
        }


        public Position this[int key]
        {
            get => this.positionList[key];
        }
    }
}
