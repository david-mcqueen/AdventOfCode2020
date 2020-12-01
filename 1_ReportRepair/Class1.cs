using System;
using System.Collections.Generic;
using System.Linq;

namespace _1_ReportRepair
{
    public class Class1
    {

        public List<long> Process(List<long> collection)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                var item = collection[i];
                var newCollection = collection.ToList();
                newCollection.RemoveAt(i);
                var answers = Recursive(newCollection, new List<long>() { item });
                if (answers.Count == 3)
                {
                    return answers;
                }
            }

            return new List<long>();
        }

        public List<long> Recursive(List<long> collection, List<long> answer)
        {

            if (answer.Count == 3)
            {
                return answer;
            }

            for (int i = 0; i < collection.Count; i++)
            {
                var item = collection[i];
                if (answer.Sum() + item > 2020)
                    continue;

                var newAnswer = answer.ToList();
                newAnswer.Add(item);

                if (newAnswer.Sum() == 2020)
                {
                    return newAnswer;
                }

                var newCollection = collection.ToList();
                newCollection.RemoveAt(i);

                var recAns = Recursive(newCollection, newAnswer);

                if (recAns.Sum() == 2020)
                    return recAns;

                continue;
            }

            return answer;
        }
    }

}
