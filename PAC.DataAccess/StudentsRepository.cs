using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PAC.Domain;
using PAC.IDataAccess;

namespace PAC.DataAccess;

public class StudentsRepository<T> : IStudentsRepository<Student> where T : class
{
    public static List<Student> students = new List<Student> { new Student() { Id = 1, Name = "Pedro", Age = 18 }, new Student() { Id = 2, Name = "Juan", Age = 25 } } ;

    public Student GetStudentById(int id)
    {
        return students.Find(u => u.Id == id);
    }

    public IEnumerable<Student> GetStudents()
    {
        return students;
    }

    public void InsertStudents(Student? student)
    {
        student!.Id = students.Count + 1;
        students.Add(student!);
    }
}
