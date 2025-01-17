using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_12
{
    public class BookList
    {
        LinkedList<Book> books = new LinkedList<Book>();

        public void AddBook(Book book)
        {
            books.AddLast(book);
        }

        public void RemoveBook(Book book)
        {
            books.Remove(book);
        }

        public void InsertBookFirst(Book book)
        {
            books.AddFirst(book);
        }

        public void InsertBookLast(Book book)
        {
            books.AddLast(book);
        }

        public void InsertBookAt(Book book, int index)
        {
            LinkedListNode<Book> node = books.First;
            for (int i = 0; i < index && node != null; i++)
            {
                node = node.Next;
            }
            if (node != null)
            {
                books.AddBefore(node, book);
            }
            else
            {
                books.AddLast(book);
            }
        }

        public void RemoveFirstBook()
        {
            books.RemoveFirst();
        }

        public void RemoveLastBook()
        {
            books.RemoveLast();
        }

        public void RemoveBookAt(int index)
        {
            LinkedListNode<Book> node = books.First;
            for (int i = 0; i < index && node != null; i++)
            {
                node = node.Next;
            }
            if (node != null)
            {
                books.Remove(node);
            }
        }

        public IEnumerable<Book> Search(Func<Book, bool> predicate)
        {
            return books.Where(predicate);
        }
    }
}
