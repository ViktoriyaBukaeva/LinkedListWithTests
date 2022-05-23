using System.Collections;

namespace LinkdList
{
    public class LnkdList<T> : IEnumerable
    {
        private Node<T> _head;
        private Node<T> _tail;

        public T this[int index]
        {
            get
            {
                if (index < 0 || index > Length - 1)
                {
                    throw new IndexOutOfRangeException();
                }

                Node<T> crnt = _head;

                for (int i = 1; i <= index; i++)
                {
                    crnt = crnt.Next;
                }
                return crnt.Value;
            }
            set
            {
                if (index < 0 || index > Length - 1)
                {
                    throw new IndexOutOfRangeException();
                }

                Node<T> crnt = _head;

                for (int i = 1; i <= index; i++)
                {
                    crnt = crnt.Next;
                }
                crnt.Value = value;
            }
        }
        public LnkdList()
        {
            _head = null;
            _tail = null;
        }
        public LnkdList(T value)
        {
            _head = new Node<T>(value);
            _tail = _head;
        }
        //public LnkdList(T[] values)
        //{
        //    foreach (T value in values)
        //    {
        //        Add(value);
        //    }
        //}

        public LnkdList(T[] values)
        {
            _head = new Node<T>(values[0]);
            _tail = _head;
            for (int i = 1; i < values.Length; i++)
            {
                _tail.Next = new Node<T>(values[i]);
                _tail = _tail.Next;
            }
        }

        public LnkdList(List<T> list)
        {
            if (list == null)
            {
                throw new NullReferenceException("Passing an empty link is not possible");
            }
            else
            {
                _head = new Node<T>(list[0]);
                _tail = _head;
                foreach (var element in list)
                {
                    _tail.Next = new Node<T>(element);
                    _tail = _tail.Next;
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            Node<T> crnt = _head;
            while (crnt != null)
            {
                yield return crnt.Value;
                crnt = crnt.Next;
            }
        }

        public override string ToString()
        {
            string s = "";
            Node<T> crnt = _head;
            while (crnt != null)
            {
                if (crnt.Value == null)
                {
                    s += "null";
                }
                else
                {
                    s += $"{crnt.Value!.ToString()} ";
                }

                crnt = crnt.Next;
            }
            return s;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is LnkdList<T>))
            {
                return false;
            }

            LnkdList<T> other = (LnkdList<T>)obj;

            if (other.Length != this.Length)
            {
                return false;
            }

            Node<T> thisCrnt = this._head;
            Node<T> otherCrnt = other._head;

            while (thisCrnt != null)
            {
                if (thisCrnt.Value == null && otherCrnt.Value == null)
                {
                    thisCrnt = thisCrnt.Next;
                    otherCrnt = otherCrnt.Next;
                    continue;
                }
                if (
                   thisCrnt.Value == null && otherCrnt.Value != null
                   || thisCrnt.Value != null && otherCrnt.Value == null
                   || !thisCrnt.Value!.Equals(otherCrnt.Value)
                   )
                {
                    return false;
                }

                thisCrnt = thisCrnt.Next;
                otherCrnt = otherCrnt.Next;
            }
            return true;
        }

        //метод добавления элемента в список в конец
        public void Add(T value)
        {
            if (_head == null)
            {
                _head = new Node<T>(value);
                _tail = _head;
            }
            else
            {
                _tail.Next = new Node<T>(value);
                _tail = _tail.Next;
            }
        }

        //метод добавления элемента в список в начало
        public void AddFirst(T value)
        {
            if (_head == null)
            {
                _head = new Node<T>(value);
                _tail = _head;
            }
            else
            {
                Node<T> current = _head;
                _head = new Node<T>(value);
                _head.Next = current;
            }
        }

        //метод добавления элемента в список по индексу
        public void AddByIndex(int index, T value)
        {
            Node<T> node = _head;
            if (index != null && index >= 0 && index < Length || _head == null)
            {
                Node<T> newNode = new Node<T>(value);
                if (_head == null)
                {
                    _head = new Node<T>(value);
                    _tail = _head;
                }
                else
                {
                    if (index == 0)
                    {
                        AddFirst(value);
                    }
                    else
                    {
                        for (int i = 0; i < index - 1; i++)
                        {
                            node = node.Next;
                        }
                        newNode.Next = node.Next;
                        node.Next = newNode;
                    }
                }
            }
            else
            {
                throw new IndexOutOfRangeException("Переданный индекс выходит за пределы списка");
            }
        }

        //метод удаления из начала списка одного элемента
        public void RemoveFirst()
        {
            if (_head != null)
            {
                _head = _head.Next;
                if (_head == null)
                {
                    _tail = null;
                }
            }
        }

        //метод удаления из конца одного элемента
        public void RemoveLast()
        {
            if (_head != null)
            {
                if (_head.Next == null)
                {
                    _head = null;
                    _tail = null;
                }
                Node<T> node = _head;
                if (Length > 1)
                {
                    while (node.Next.Next != null)
                    {
                        node = node.Next;
                    }
                    _tail = node;
                    node.Next = null;
                }
            }
        }

        //метод удаления одного элемента по индексу
        public void RemoveByIndex(int index)
        {
            Node<T> node = _head;

            if (index != null && index < Length - 1 && index > 0 || index == 0 )
            {
                if (index == 0)
                {
                    _head = _head.Next;
                }
                else
                {
                    for (int i = 0; i < index - 1; i++)
                    {
                        node = node.Next;
                    }
                    node.Next = node.Next.Next;
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        //метод удаления из конца N элементов
        public void RemoveEndNElem(int elements)
        {
            if (elements == 0)
            {
                throw new ArgumentException("Вы не передали число для удаления элементов списка");
            }
            if (elements < 0)
            {
                throw new ArgumentException("Число переданных элементов не может быть меньше 0");
            }
            if (Length >= elements)
            {
                if (_head.Next == null || Length <= elements)
                {
                    _head = null;
                    _tail = null;
                }
                else
                {
                    Node<T> node = _head;
                    for (int i = 0; i < Length - elements - 1; i++)
                    {
                        node = node.Next;
                    }
                    node.Next = null;
                    _tail = node;
                }

            }
            else
            {
                throw new IndexOutOfRangeException("Число удаляемых элементов больше,чем длина списка");
            }
        }

        //метод удаления из начала N элементов 
        public void RemoveStart_N_Elem(int elements)
        {
            if (elements <= 0)
            {
                throw new ArgumentException("Вы не передали число для удаления элементов списка");
            }
            if (_head != null)
            {
                if (_head.Next == null || Length <= elements)
                {
                    _head = null;
                    _tail = null;
                }
                if (Length > elements)
                {
                    Node<T> node = _head;
                    for (int i = 0; i < elements; i++)
                    {
                        _head = _head.Next;
                    }
                }
            }
            else
            {
                throw new IndexOutOfRangeException("Число удаляемых элементов больше,чем длина списка");
            }
        }

        //метод удаления по индексу N элементов
        public void Remove_N_ElemByIndex(int index, int elements)
        {
            if (index > Length - 1 || index < 0)
            {
                throw new IndexOutOfRangeException("Вы вышли за пределы списка");
            }
            Node<T> node = _head;
            if (index != null && index > 0 && index < Length - 1 && elements <= Length - index)
            {
                for (int i = 0; i < index - 1; i++)
                {
                    node = node.Next;
                }
                Node<T> nextNode = node;
                for (int i = 0; i < elements; i++)
                {
                    nextNode = nextNode.Next;
                }
                node.Next = nextNode.Next;
            }
            else
            {
                throw new ArgumentException("Переданное число элементов превышает число элементов списка " +
                    "или переданное число удаляемых элементов после индекса отсутствует");
            }
        }

        //вернуть длину
        public int Length
        {
            get
            {
                if (_head == null)
                {
                    return 0;
                }

                int counter = 1;
                Node<T> crnt = _head;
                while (crnt.Next != null)
                {
                    crnt = crnt.Next;
                    counter++;
                }
                return counter;
            }
            private set
            {
            }
        }

        //метод поиска первого индекса по значению
        public int SearchIndexOf(T value)
        {
            Node<T> node = _head;
            if (_head != null)
            {
                int index = 0;
                while (node.Next != null)
                {
                    if (node.Value.Equals(value))
                    {
                        return index;
                    }
                    node = node.Next;
                    index++;
                }
            }
            return -1;
        }

        //метод	реверса (123 -> 321) 
        public void Revers()
        {
            Node<T> node = _head;
            Node<T> oldTail = _tail;
            if (Length > 1)
            {
                while (oldTail != _head)
                {
                    _head = node.Next; //12345
                    node.Next = oldTail.Next;
                    oldTail.Next = node; //23451
                    if (_tail.Next != null)
                    {
                        _tail = _tail.Next; //указатель tail с 5 переставляем на 1                         
                    }
                    node = _head;//в node сохранили ссылку на 1 элемент, для нового прохождения цикла
                }
            }
        }

        //метод поиска и удаления первого индекса по значению
        public int SearchIndexAndRemove(T value)
        {
            Node<T> node = _head;
            if (_head != null)
            {
                int index = 0;
                while (node.Next != null)
                {
                    if (node.Value.Equals(value))
                    {
                        RemoveByIndex(index);
                        return index;
                    }
                    node = node.Next;
                    index++;
                }
            }
            return -1;
        }

        //метод поиска и удаления по значению всех элементов
        public int SearchAndRemoveAllElements(T value)
        {
            int count = 0;
            if (_head != null)
            {
                while (_head != null && _head.Value.Equals(value))
                {
                    _head = _head.Next;
                    count++;
                }
                if (_head != null)
                {
                    Node<T> node = _head.Next;
                    Node<T> previous = _head;
                    while (previous.Next != null)
                    {
                        if (node.Value.Equals(value))
                        {
                            previous.Next = node.Next;
                            node = node.Next;
                            count++;
                        }
                        else
                        {
                            node = node.Next;
                            previous = previous.Next;
                        }
                    }
                }
            }
            return count;
        }

        //метод добавления списка в конец
        public void AddListInListEnd(LnkdList<T> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException("Вы передаете пустой список");
            }
            foreach (T i in list)
            {
                Add(i);
            }
        }

        //метод добавления списка в начало 
        public void AddListInListFirst(LnkdList<T> list)
        {
            AddListInListByIndex(list, 0);
        }

        //метод добавления списка по индексу 
        public void AddListInListByIndex(LnkdList<T> list, int index)
        {
            foreach (T i in list)
            {
                AddByIndex(index, i);
                index++;
            }
        }

    }
}
