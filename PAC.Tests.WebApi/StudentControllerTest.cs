namespace PAC.Tests.WebApi;
using Moq;
using PAC.IBusinessLogic;
using PAC.Domain;
using PAC.WebAPI;
using Microsoft.AspNetCore.Mvc;

[TestClass]
public class StudentControllerTest
{
    private Mock<IStudentLogic>? mockStudentLogic;
    private StudentController? studentController;
    private Student? student;


    [TestInitialize]
    public void InitTest()
    {
        mockStudentLogic = new Mock<IStudentLogic>(MockBehavior.Strict);
        studentController = new StudentController(mockStudentLogic.Object);
    }

    [TestMethod]
    public void PostStudentOk()
    {
        mockStudentLogic!.Setup(x => x.InsertStudents(It.IsAny<Student>()));

        var result = studentController!.AddStudent(student!);
        var objectResult = result as ObjectResult;
        var statusCode = objectResult!.StatusCode;

        mockStudentLogic!.VerifyAll();
        Assert.AreEqual(200, statusCode);
    }

    [TestMethod]
    public void PostStudentFail()
    {
        mockStudentLogic!.Setup(x => x.InsertStudents(It.IsAny<Student>())).Throws(new Exception());
        var result = studentController!.AddStudent(It.IsAny<Student>());
        var objectResult = result as ObjectResult;
        var statusCode = objectResult!.StatusCode;

        mockStudentLogic.VerifyAll();
        Assert.AreEqual(500, statusCode);
    }
}
