using System;
using System.Collections.Generic;

namespace iBosAssesmentAPI.Models;

public partial class TblEmployee
{
    public int? EmployeeId { get; set; }

    public string? EmployeeName { get; set; }

    public string? EmployeeCode { get; set; }

    public decimal? EmployeeSalary { get; set; }

    public int? SupervisorId { get; set; }
}
