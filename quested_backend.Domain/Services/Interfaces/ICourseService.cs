using System.Collections.Generic;
using System.Threading.Tasks;
using quested_backend.Domain.Requests_DTOs.Course;
using quested_backend.Domain.Responses_DTOs;

namespace quested_backend.Domain.Services.Interfaces
{
    using Marks = Task<Dictionary<int, List<int>>>;
    using AvgMark = Task<Dictionary<int, double>>;
    
    /// <summary>
    /// Interface with the main business logic of the application. Service class provides
    /// functionality of Courses.
    /// </summary>
    public interface ICourseService
    {
        /// <summary>
        /// Gets all courses in the database mapped into course responses
        /// </summary>
        /// <returns>IEnumerable of course responses</returns>
        Task<IEnumerable<CourseResponse>> GetCoursesAsync();
        
        /// <summary>
        /// Gets course conforming to the course request mapped into course response.
        /// The course entity itself begins to be tracked by the DB context
        /// </summary>
        /// <param name="request">object defining which course to get</param>
        /// <returns>course response</returns>
        Task<CourseResponse> GetCourseAsync(GetCourseRequest request);
        
        /// <summary>
        /// Gets course conforming to the course request mapped into course response.
        /// The course entity itself is not tracked by the DB context, therefore
        /// no changes on the entity will be committed
        /// </summary>
        /// <param name="request">object defining which course to get</param>
        /// <returns>course response</returns>
        Task<CourseResponse> ReadOnlyGetCourseAsync(GetCourseRequest request);
        
        /// <summary>
        /// Adds course to the database with attributes of the add course request
        /// </summary>
        /// <param name="request">object containing attributes of course entity</param>
        /// <returns>added course mapped into a course response</returns>
        Task<CourseResponse> AddCourseAsync(AddCourseRequest request);
        
        /// <summary>
        /// Edits attributes of existing course from edit course request
        /// </summary>
        /// <param name="request">object containing new data to be edited in existing course</param>
        /// <returns>edited course</returns>
        Task<CourseResponse> EditCourseAsync(EditCourseRequest request);
        
        Task<CourseResponse> DeleteCourseById(int courseId);

        /// <summary>
        /// Creates a dictionary where keys are pupil's IDs and values are lists of their scores
        /// </summary>
        /// <param name="courseId">ID of course for which to create the dictionary</param>
        /// <returns>dictionary of ints and lists of ints</returns>
        Marks GetScoresOfAllPupils(int courseId);

        /// <summary>
        /// Creates a dictionary where keys are pupil's IDs and values are averages of their scores
        /// </summary>
        /// <param name="courseId">ID of course for which to create the dictionary</param>
        /// <returns>dictionary of ints and doubles</returns>
        AvgMark GetAvgScoreOfPupils(int courseId);

    }
}