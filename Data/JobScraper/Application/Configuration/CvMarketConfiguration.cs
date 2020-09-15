using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Configuration
{
    public class CvMarketConfiguration : IScrapeConfiguration
    {
        public string Posting { get; set; } = "tr.f_job_row2";
        public string Company { get; set; } = ".f_job_company";
        public string Salary { get; set; } = "span.f_job_salary";
        public string Name { get; set; } = "a.f_job_title";
        public string Url { get; set; } = "a.f_job_title";

    }
}
