using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ReviewService
    {
        public static bool CreateReview(ReviewDTO obj, int customerId)
        {
            var newReview = new Review()
            {
                Description = obj.Description,
                Product_Id = obj.Product_Id,
                Customer_Id = customerId,
            };
            return DataFactory.ReviewData().Create(newReview);
        }
        public static bool EditReview(ReviewDTO obj, int customerId)
        {
            var exReview = DataFactory.ReviewData().Get(obj.Id);
            if(exReview == null || exReview.Customer_Id != customerId) { return false; }
            //editting review
            exReview.Description= obj.Description;
            return DataFactory.ReviewData().Update(exReview);
        }
        public static bool DeleteReview(int reviewId, int customerId)
        {
            var exReview = DataFactory.ReviewData().Get(reviewId);
            if (exReview == null || exReview.Customer_Id != customerId) { return false; }
            //deleting review
            return DataFactory.ReviewData().Delete(reviewId);
        }

        public static ReviewDTO GetReview(int reviewId)
        {
            var reviewList = DataFactory.ReviewData().Get(reviewId);
            var config = new MapperConfiguration(cfg=>cfg.CreateMap<Review, ReviewDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<ReviewDTO>(reviewList);
        }
        public static List<ReviewDTO> GetMyReview(int customerId)
        {
            var reviewList = DataFactory.ReviewData().Get().Where(x => x.Customer_Id.Equals(customerId)).ToList();
            var config = new MapperConfiguration(cfg=>cfg.CreateMap<Review, ReviewDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<List<ReviewDTO>>(reviewList);
        }
        public static List<ReviewDTO> GetProductReview(int productId)
        {
            var reviewList = DataFactory.ReviewData().Get().Where(x => x.Product_Id.Equals(productId)).ToList();
            var config = new MapperConfiguration(cfg=>cfg.CreateMap<Review, ReviewDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<List<ReviewDTO>>(reviewList);
        }
    }
}
