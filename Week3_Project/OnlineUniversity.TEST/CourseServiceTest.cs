// using OnlineUniversity.API.Service;
using Moq;
using OnlineUniversity.API.Repository;
using OnlineUniversity.API.Model;
using OnlineUniversity.API.Service;

namespace OnlineUniversity.TEST;

public class UnitTest3
{
    [Fact]
    public void GetAllCoursesTest()
    {
        //Arrange
        Mock<ICourseRepository> mockRepo = new();
        CourseService CourseService = new(mockRepo.Object);

        List<Course> CourseList = [
            new Course { Id = 1, Name = "TestCourse1" },
            new Course { Id = 1, Name = "TestCourse2" },
            new Course { Id = 1, Name = "TestCourse3" },

        ];

        mockRepo.Setup(repo => repo.GetAllCourses()).Returns(CourseList);

        //Act
        var result = CourseService.GetAllCourses().ToList();

        //Assert
        Assert.Equal(CourseList, result);
    }

    [Fact]
    public void TestCreateNewCourse()
    {
        //Arrange
        Mock<ICourseRepository> mockRepo = new();
        CourseService CourseService = new(mockRepo.Object);

        List<Course> CourseList = [
            new Course { Id = 1, Name = "TestCourse1" },
            new Course { Id = 1, Name = "TestCourse2" },
            new Course { Id = 1, Name = "TestCourse3" },
        ];

        Course newCourse = new Course { Id = 1, Name = "TestCourse3" };

        mockRepo.Setup(repo => repo.AddCourse(It.IsAny<Course>()))
            .Callback((Course Course) => CourseList.Add(Course))
            .ReturnsAsync(newCourse);


        //Act
        var myCourse = CourseService.AddCourse(newCourse);

        //Assert
        Assert.Contains(newCourse, CourseList);
        mockRepo.Verify(x => x.AddCourse(It.IsAny<Course>()), Times.Once());
    }

    [Fact]
    public void TestGetCourseById()
    {
        // Arrange
        Mock<ICourseRepository> mockRepo = new();
        CourseService CourseService = new(mockRepo.Object);
        Course course = new Course { Id = 1, Name = "TestCourse3" };

        mockRepo.Setup(repo => repo.GetCourseById(1)).Returns(course);

        // Act
        var result = CourseService.GetCourseById(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(course.Id, result.Id);
        mockRepo.Verify(repo => repo.GetCourseById(1), Times.Once);
    }
}