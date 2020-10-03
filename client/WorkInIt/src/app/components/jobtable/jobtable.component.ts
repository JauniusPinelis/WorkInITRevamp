import { Component, OnInit } from '@angular/core';
import { JobService } from 'src/app/services/job.service';
import { CompanyService } from 'src/app/services/company.service'
 import {Job } from '../../models/Job';
 import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'job-table',
  templateUrl: './jobtable.component.html',
  styleUrls: ['./jobtable.component.scss']
})
export class JobtableComponent implements OnInit {

  jobs: Job[];
  thumbnail: any;

  constructor(
    private jobService: JobService,
    private companyService: CompanyService,
    private sanitizer: DomSanitizer
    ) { }

  ngOnInit(): void {
    this.retrieveJobs();
    this.testGetImage();
  }

  retrieveJobs(): void {
    this.jobService.getAll().subscribe(
      data => {
        this.jobs = data;
        console.log(data);
      },
      error => {
        console.log(error);
      }
    )
  }

  testGetImage(): void {
    this.companyService.getImage(1225).subscribe(
      data => {
        let objectURL = "data:image/" + data.extension + ";base64," + data.imageData;

        this.thumbnail = this.sanitizer.bypassSecurityTrustUrl(objectURL);
        console.log(data);
      },
      error => {
        console.log(error);
      }
    )
  }

}
