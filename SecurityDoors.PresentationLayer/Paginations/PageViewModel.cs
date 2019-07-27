using System;

namespace SecurityDoors.PresentationLayer.Paginations
{
    /// <summary>
    /// Класс для постраничная навигация.
    /// </summary>
    public class PageViewModel
    {
        /// <summary>
        /// Номер страницы.
        /// </summary>
        public int PageNumber { get; private set; }

        /// <summary>
        /// Количество страниц.
        /// </summary>
        public int TotalPages { get; private set; }

        /// <summary>
        /// Конструктор с параметрами.
        /// </summary>
        /// <param name="count">счетчик.</param>
        /// <param name="pageNumber">номер страницы.</param>
        /// <param name="pageSize">размер страницы.</param>
        public PageViewModel(int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }

        /// <summary>
        /// Предыдущая страница.
        /// </summary>
        public bool HasPreviousPage
        {
            get
            {
                return (PageNumber > 1);
            }
        }

        /// <summary>
        /// Следующая страница.
        /// </summary>
        public bool HasNextPage
        {
            get
            {
                return (PageNumber < TotalPages);
            }
        }
    }
}
