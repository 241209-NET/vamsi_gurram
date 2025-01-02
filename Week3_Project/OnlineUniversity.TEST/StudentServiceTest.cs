// using OnlineUniversity.API.Service;
using Moq;
using OnlineUniversity.API.Repository;
using OnlineUniversity.API.Model;
using OnlineUniversity.API.Service;

namespace OnlineUniversity.TEST;

public class UnitTest1
{
    [Fact]
    public void GetAllStudentsTest()
    {
        //Arrange
        Mock<IStudentRepository> mockRepo = new();
        StudentService StudentService = new(mockRepo.Object);

        List<Student> StudentList = [
            new Student { Id = 1, Name = "Testuser1", Age = 21, Address = "abc" },
            new Student { Id = 1, Name = "TestUser2", Age = 20, Address = "abc" },
            new Student { Id = 1, Name = "TestUser3", Age = 22, Address = "abc" },

        ];

        mockRepo.Setup(repo => repo.GetAllStudents()).Returns(StudentList);

        //Act
        var result = StudentService.GetAllStudents().ToList();

        //Assert
        Assert.Equal(StudentList, result);
    }

    [Fact]
    public void TestCreateNewStudent()
    {
        //Arrange
        Mock<IStudentRepository> mockRepo = new();
        StudentService StudentService = new(mockRepo.Object);

        List<Student> StudentList = [
            new Student { Id = 1, Name = "Testuser1", Age = 21, Address = "abc" },
            new Student { Id = 1, Name = "TestUser2", Age = 20, Address = "abc" },
            new Student { Id = 1, Name = "TestUser3", Age = 22, Address = "abc" },
        ];

        Student newStudent = new Student { Id = 1, Name = "TestUser5", Age = 22, Address = "abc" };

        mockRepo.Setup(repo => repo.AddStudent(It.IsAny<Student>()))
            .Callback((Student student) => StudentList.Add(student))
            .ReturnsAsync(newStudent);


        //Act
        var myStudent = StudentService.AddStudent(newStudent);

        //Assert
        Assert.Contains(newStudent, StudentList);
        mockRepo.Verify(x => x.AddStudent(It.IsAny<Student>()), Times.Once());
    }

    [Fact]
    public void TestGetStudentById()
    {
        // Arrange
        Mock<IStudentRepository> mockRepo = new();
        StudentService StudentService = new(mockRepo.Object);
        Student student = new Student { Id = 1, Name = "TestUser5", Age = 22, Address = "abc" };

        mockRepo.Setup(repo => repo.GetStudentById(1)).Returns(student);

        // Act
        var result = StudentService.GetStudentById(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(student.Id, result.Id);
        mockRepo.Verify(repo => repo.GetStudentById(1), Times.Once);
    }
}