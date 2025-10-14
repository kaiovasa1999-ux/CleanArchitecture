namespace TopCodingStringTasks;

public class IsomorphicString
{
    public int CountStudents(int[] students, int[] sandwiches)
    {
        var q = new Queue<int>();
        var stack = new Stack<int>();

        foreach (var s in students)
        {
            q.Enqueue(s);
        }
        foreach (var s in sandwiches)
        {
            stack.Push(s);
        }

        var count = 0;
        while (q.Count > 0 || stack.Count > 0)
        {

            var student = q.Peek();
            var sandwich = stack.Peek();

            if (student == sandwich)
            {
                stack.Pop();
                q.Dequeue();
            }
            else
            {
                count++;
                var person = q.Dequeue();
                q.Enqueue(person);
            }
        }

        return count;
    }
}