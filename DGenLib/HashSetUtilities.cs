namespace DGenLib
{
    public static class HashSetUtilities
    {
        public static T GetAndRemoveRandomElement<T>(HashSet<T> data)
        {
            var random = new Random();
            int elementIndex = random.Next(0, data.Count);
            int i = 0;

            foreach (var element in data)
            {
                if (i == elementIndex)
                {
                    data.Remove(element);
                    return element;
                }

                i++;
            }

            return default(T);
        }
    }
}
