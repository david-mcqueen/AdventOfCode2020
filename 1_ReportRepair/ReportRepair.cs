using System;
using System.Collections.Generic;
using System.Linq;

namespace _1_ReportRepair
{
    public class ReportRepair
    {
        private int depth;
        private long target;

        public ReportRepair(long target, int depth)
        {
            this.target = target;
            this.depth = depth;
        }

        public List<long> Process(List<long> collection)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                var item = collection[i];
                var newCollection = collection.ToList();
                newCollection.RemoveAt(i);
                var answers = Recursive(newCollection, new List<long>() { item });

                if (answers.Count == depth)
                {
                    return answers;
                }
            }

            return new List<long>();
        }

        private List<long> Recursive(List<long> collection, List<long> answer)
        {

            if (answer.Count == depth)
            {
                return answer;
            }

            foreach (var item in collection)
            {
                if (answer.Sum() + item > target)
                    continue;

                var newAnswer = answer.ToList();
                newAnswer.Add(item);
                
                if (newAnswer.Sum() == target)
                    return newAnswer;
                
                var newCollection = collection.ToList();
                newCollection.Remove(item);

                var recAns = Recursive(newCollection, newAnswer);

                if (recAns.Sum() == target)
                    return recAns;

                continue;
            }


            return answer;
        }
    }

}
