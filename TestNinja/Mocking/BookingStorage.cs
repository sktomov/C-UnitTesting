using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IBookingStorage
    {
        IQueryable<Booking> GetAllBookingsWithActiveStatusAndDifferentByGivenId(int id);
    }

    public class BookingStorage : IBookingStorage
    {
        private readonly UnitOfWork _unitOfWork;

        public BookingStorage()
        {
            _unitOfWork = new UnitOfWork();
        }

        public IQueryable<Booking> GetAllBookingsWithActiveStatusAndDifferentByGivenId(int id)
            => _unitOfWork.Query<Booking>()
                .Where(
                    b => b.Id != id && b.Status != "Cancelled");
    }


    public class UnitOfWork
    {
        public IQueryable<T> Query<T>()
        {
            return new List<T>().AsQueryable();
        }
    }
}
