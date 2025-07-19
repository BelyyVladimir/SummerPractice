using Xunit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

public class SerializationTests
{
    [Fact]
    public void CanSerializeAndDeserializeStudentRecord()
    {
        var originalStudent = new Student
        {
            FirstName = "Petin",
            LastName = "Dmitriy",
            BirthDate = new DateTime(1999, 9, 9),
            Grades = new List<Subject>
            {
                new Subject { Name = "OOAIP", Grade = 3 },
                new Subject { Name = "ORG", Grade = 5 }
            }
        };

        string json = JsonService.Serialize(originalStudent);
        Student? deserializedStudent = JsonService.Deserialize(json);
        if (deserializedStudent != null)
        {


            Assert.NotNull(deserializedStudent);
            Assert.Equal("Petin", deserializedStudent.FirstName);
            Assert.Equal("Dmitriy", deserializedStudent.LastName);
            Assert.Equal(new DateTime(1999, 9, 9), deserializedStudent.BirthDate);
            Assert.Equal(2, deserializedStudent.Grades?.Count);
        }
    }

    [Fact]
    public void SerializationIgnoresNullByDefault()
    {
        var student = new Student
        {
            FirstName = "Черный",
            LastName = "Александр",
            BirthDate = new DateTime(2006, 02, 03),
            Grades = null 
        };

        string json = JsonService.Serialize(student);

        Assert.DoesNotContain("Grades", json);
    }

    [Fact]
    public void DeserializationHandlesMissingData()
    {

        string json = @"{""FirstName"": ""Ваня"", ""LastName"": ""Смирнов"", ""BirthDate"": ""2000-12-21""}";

        Student? student = JsonService.Deserialize(json);

        Assert.NotNull(student);
        Assert.Equal("Ваня", student.FirstName);
        Assert.Equal("Смирнов", student.LastName);
        Assert.Equal(new DateTime(2000, 12, 21), student.BirthDate);
        Assert.Null(student.Grades);
    }
}