using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Product_Review_Management_LINQ
{
    class Management
    {
        public readonly DataTable dataTable = new DataTable();

        // UC2- Retrieve Top 3 records from list.
        public void TopRecords(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReviews in listProductReview
                                orderby productReviews.Rating descending
                                select productReviews).Take(3);
            Console.WriteLine("\nTop 3 records = ");
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductId:-" + list.ProductId + " UserId:-" + list.UserId + " Ratings:-" + list.Rating + " Review:-" + list.Review + " IsLike:-" + list.isLike);
            }
        }

        // UC3- Selects the record with rating grater than 3 and with product id = 1,4,9.
        public void SelectedRecords(List<ProductReview> listProductReview)
        {
            var recordedData = from productReviews in listProductReview
                               where (productReviews.ProductId == 1 || productReviews.ProductId == 4 || productReviews.ProductId == 9) && productReviews.Rating > 3
                               select productReviews;
            Console.WriteLine("\nRating grater than 3 with product id 1,4,9 = ");
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductId:-" + list.ProductId + " UserId:-" + list.UserId + " Ratings:-" + list.Rating + " Review:-" + list.Review + " IsLike:-" + list.isLike);
            }
        }

        // UC4- Retrieves the count of record with  the help of group by id.
        public void RetrieveCountOfRecords(List<ProductReview> listProductReview)
        {
            var recordedData = listProductReview.GroupBy(x => x.ProductId).Select(x => new { ProductId = x.Key, Count = x.Count() });
            Console.WriteLine("\nProduct id and count = ");
            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ProductId + " = " + list.Count);
            }
        }
    }
}