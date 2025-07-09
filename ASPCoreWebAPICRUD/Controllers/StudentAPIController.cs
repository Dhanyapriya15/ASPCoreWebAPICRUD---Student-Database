using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using ASPCoreWebAPICRUD.Models;
using System.Collections.Generic;

namespace ASPCoreWebAPICRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly string connectionString = "Server=localhost;Database=taskdb;Uid=root;Pwd=root;";

        // GET: api/StudentAPI
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            var students = new List<Student>();
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            var cmd = new MySqlCommand("SELECT * FROM Students", connection);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                students.Add(new Student
                {
                    Id = reader.GetInt32("id"),
                    StudentName = reader.GetString("Stuname"),
                    Department = reader.GetString("Department")
                });
            }

            return Ok(students);
        }

        // GET: api/StudentAPI/5
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(int id)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            var cmd = new MySqlCommand("SELECT * FROM Students WHERE id = @id", connection);
            cmd.Parameters.AddWithValue("@id", id);
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                var student = new Student
                {
                    Id = reader.GetInt32("id"),
                    StudentName = reader.GetString("Stuname"),
                    Department = reader.GetString("Department")
                };
                return Ok(student);
            }

            return NotFound();
        }

        // POST: api/StudentAPI
        [HttpPost]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            var cmd = new MySqlCommand("INSERT INTO Students (id, Stuname, Department) VALUES (@id, @name, @dept)", connection);
            cmd.Parameters.AddWithValue("@id", student.Id);
            cmd.Parameters.AddWithValue("@name", student.StudentName);
            cmd.Parameters.AddWithValue("@dept", student.Department);

            var rows = cmd.ExecuteNonQuery();
            return rows == 1 ? Ok("✅ Student inserted successfully!") : BadRequest("❌ Insertion failed.");
        }

        // PUT: api/StudentAPI/5
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student student)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            var cmd = new MySqlCommand("UPDATE Students SET Stuname = @name, Department = @dept WHERE id = @id", connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", student.StudentName);
            cmd.Parameters.AddWithValue("@dept", student.Department);

            var rows = cmd.ExecuteNonQuery();
            return rows == 1 ? Ok("✅ Student updated successfully!") : NotFound("❌ No student found to update.");
        }

        // DELETE: api/StudentAPI/5
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            var cmd = new MySqlCommand("DELETE FROM Students WHERE id = @id", connection);
            cmd.Parameters.AddWithValue("@id", id);

            var rows = cmd.ExecuteNonQuery();
            return rows == 1 ? Ok("✅ Student deleted successfully!") : NotFound("❌ No student found to delete.");
        }
    }
}
