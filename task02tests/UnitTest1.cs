using Xunit;
using task02;

public class StudentServiceTests
{
    private List<Student> _testStudents;
    private StudentService _service;

    public StudentServiceTests()
    {
        _testStudents = new List<Student>
        {
            new() { Name = "����", Faculty = "���", Grades = new List<int> { 5, 4, 5 } },
            new() { Name = "����", Faculty = "���", Grades = new List<int> { 3, 4, 3 } },
            new() { Name = "����", Faculty = "���������", Grades = new List<int> { 5, 5, 5 } }
        };
        _service = new StudentService(_testStudents);
    }

    [Fact]
    public void GetStudentsByFaculty_ReturnsCorrectStudents()
    {
        var result = _service.GetStudentsByFaculty("���").ToList();
        Assert.Equal(2, result.Count);
        Assert.True(result.All(s => s.Faculty == "���"));
    }

    [Fact]
    public void GetFacultyWithHighestAverageGrade_ReturnsCorrectFaculty()
    {
        var result = _service.GetFacultyWithHighestAverageGrade();
        Assert.Equal("���������", result);
    }

    [Fact]
    public void SortByName_ReturnsStudentsSortedByName()
    {
        var result = _service.GetStudentsOrderedByName().ToList();
        Assert.Equal("����", result[0].Name);
        Assert.Equal("����", result[1].Name);
        Assert.Equal("����", result[2].Name);
    }

    [Fact]
    public void GroupingByFaculty_ReturnsStudentsGroupedByFaculty()
    {
        var result = _service.GroupStudentsByFaculty().ToList();
        Assert.Equal(2, result.Count);
        Assert.Equal("���", result[0].Key);
        Assert.Equal("���������", result[1].Key);
    }

    [Fact]
    public void GetStudentsWithHighScore_ReturnsListStudents()
    {
        var result = _service.GetStudentsWithMinAverageGrade(4).ToList();
        Assert.True(result.All(s => s.Grades.Average() >= 4.0));
    }
}