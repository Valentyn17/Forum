import { Component, Input, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-update-section',
  templateUrl: './add-update-section.component.html',
  styleUrls: ['./add-update-section.component.css']
})
export class AddUpdateSectionComponent implements OnInit {
  @Input() section :any;
  Id: any;
  Name:string;
  TopicsIds:any[];

  constructor(private service:SharedService, private toastr: ToastrService) { }

  ngOnInit(): void {
    console.log('here');
    this.Id=this.section.id;
    this.Name=this.section.name;
  }

  checkInputOnAdd(): boolean {
    if (this.Name == '') {
      this.toastr.error('Some fields are empty', 'Error');
      return false;
    }
    return true;
  }

  addSection() {
    if (!this.checkInputOnAdd()) {
      return;
    }

    var item = {
      // Id: this.Id,
      Name: this.Name,
      TopicsIds: this.TopicsIds
    }

    this.service.addSection(item).subscribe({
      complete: () => {
      this.toastr.success('New section created!', 'Adding successful.');
    }, 
    error: () => {
      this.toastr.error('Something goes wrong','Adding failed.');
    }  });
  }

  updateSection() {
    var item = {
      Id: this.Id,
      Name: this.Name,
      TopicsIds: this.TopicsIds
    }

    this.service.updateSection(item).subscribe({
      complete: () => {
      this.toastr.success('Section updated!', 'Updating successful.');
    }, 
    error: () => {
      this.toastr.error('Something goes wrong','Updating failed.');
    }  });
  }
}
