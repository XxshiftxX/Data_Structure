using System;

namespace Data_Structure
{
    // 리스트를 구현한 클래스
    public class List<T>
    {
        public class Node
        {
            public T Data;
            public Node Next = null;

            public Node(T i)
            {
                Data = i;
            }
        }

        // 가장 첫번재 노드
        Node head;

        // 첫번째 노드 미지정 시 null로 입력 >> Add를 통해 추가 가능
        public List()
        {
            head = null;
        }

        // 첫번째 노드는 생성자로 지정
        public List(Node node)
        {
            head = node;
        }

        // 편한 접근을 위한 Indexer
        public Node this[int index]
        {
            get
            {
                Node result = head;
                for(int i = 0; i < index; i++)
                {
                    if(result.Next == null)
                    {
                        throw new IndexOutOfRangeException();
                    }
                    result = result.Next;
                }
                return result;
            }

            set
            {
                Node result = head;
                for (int i = 0; i < index; i++)
                {
                    if (result.Next == null)
                    {
                        throw new IndexOutOfRangeException();
                    }

                    result = result.Next;
                }
                result = value;
            }
        }

        // 리스트의 길이를 리턴하는 프로퍼티
        public int Length
        {
            get
            {
                int i = 1;
                Node now = head;
                while (now.Next != null)
                {
                    i++;
                    now = now.Next;
                }
                return i;
            }
        }

        // 리스트의 맨 뒤에 항목 하나를 추가하는 함수
        public void Add(Node node)
        {
            if (head == null)
            {
                head = node;
                return;
            }

            Node now = head;
            while(now.Next != null)
            {
                now = now.Next;
            }
            now.Next = node;
        }

        // 인자로 Node.Data의 타입을 받음. (Add의 오버로드)
        public Node Add(T node)
        {
            if (head == null)
            {
                head = new Node(node);
                return head;
            }

            Node now = head;
            while (now.Next != null)
            {
                now = now.Next;
            }

            now.Next = new Node(node);
            return now.Next;
        }

        // 리스트의 특정 인덱스의 항목을 삭제하기 위한 함수
        public void Remove(int index)
        {
            Node now = head;
            Node prev = null;
            for(int i = 0; i < index; i++)
            {
                if (now.Next == null)
                    throw new IndexOutOfRangeException();

                prev = now;
                now = now.Next;
            }

            prev.Next = now.Next;
        }

        // 리스트의 특정 인덱스에 항목을 삽입하기 위한 함수
        public void Insert(int index, Node node)
        {
            Node now = head;
            for (int i = 0; i < index; i++)
            {
                now = now.Next;
            }
            node.Next = now.Next;
            now.Next = node;
        }
    }

    class List_Program
    {
        static void Main(string[] args)
        {
            List<int> test = new List<int>(new List<int>.Node(100));

            // 리스트 상태 : 100

            test.Add(new List<int>.Node(10));
            test.Add(new List<int>.Node(3));

            // 리스트 상태 : 100 - 10 - 3

            Console.WriteLine(test[1].Data); // 10

            test[1].Data = 25;

            // 리스트 상태 : 100 - 25 - 3

            Console.WriteLine(test[1].Data); // 25

            test.Remove(1);

            // 리스트 상태 : 100 - 3

            Console.WriteLine(test[1].Data); // 3

            test.Insert(0, new List<int>.Node(19));

            // 리스트 상태 : 100 - 19 - 3

            Console.WriteLine(test[1].Data + " / " + test[2].Data); // 19 / 3
            Console.WriteLine(test.Length); // 3

            test[3] = null;
        }
    }
}
