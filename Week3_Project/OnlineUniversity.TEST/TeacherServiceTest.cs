// using OnlineUniversity.API.Service;
using Moq;
using OnlineUniversity.API.Repository;
using OnlineUniversity.API.Model;
using OnlineUniversity.API.Service;

namespace OnlineUniversity.TEST;

public class UnitTest4
{
    [Fact]
    public void GetAllTeachersTest()
    {
        //Arrange
        Mock<ITeacherRepository> mockRepo = new();
        TeacherService TeacherService = new(mockRepo.Object);

        List<Teacher> TeacherList = [
            new Teacher { Id = 1, Name = "TestTeacher1", experience = 5, rating = 5  },
            new Teacher { Id = 1, Name = "TestTeacher2", experience = 5, rating = 5  },
            new Teacher { Id = 1, Name = "TestTeacher3",experience = 5, rating = 5  },

        ];

        mockRepo.Setup(repo => repo.GetAllTeachers()).Returns(TeacherList);

        //Act
        var result = TeacherService.GetAllTeachers().ToList();

        //Assert
        Assert.Equal(TeacherList, result);
    }

    public void TestCreateNewTeacher()
    {
        //Arrange
        Mock<ITeacherRepository> mockRepo = new();
        TeacherService TeacherService = new(mockRepo.Object);

        List<Teacher> TeacherList = [
            new Teacher { Id = 1, Name = "TestTeacher1", experience = 5, rating = 5 },
            new Teacher { Id = 1, Name = "TestTeacher2", experience = 5, rating = 5  },
            new Teacher { Id = 1, Name = "TestTeacher3",experience = 5, rating = 5  },
        ];

        Teacher newTeacher = new Teacher { Id = 1, Name = "TestTeacher3", experience = 5, rating = 5 };

        mockRepo.Setup(repo => repo.AddTeacher(It.IsAny<Teacher>()))
            .Callback((Teacher Teacher) => TeacherList.Add(Teacher))
            .ReturnsAsync(newTeacher);


        //Act
        var myTeacher = TeacherService.AddTeacher(newTeacher);

        //Assert
        Assert.Contains(newTeacher, TeacherList);
        mockRepo.Verify(x => x.AddTeacher(It.IsAny<Teacher>()), Times.Once());
    }

    [Fact]
    public void TestGetTeacherById()
    {
        // Arrange
        Mock<ITeacherRepository> mockRepo = new();
        TeacherService teacherService = new(mockRepo.Object);
        Teacher teacher = new Teacher { Id = 1, Name = "TestTeacher3", experience = 5, rating = 5 };

        mockRepo.Setup(repo => repo.GetTeacherById(1)).Returns(teacher);

        // Act
        var result = teacherService.GetTeacherById(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(teacher.Id, result.Id);
        mockRepo.Verify(repo => repo.GetTeacherById(1), Times.Once);
    }


}