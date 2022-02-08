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
  topicsIds:any[];

  constructor(private service:SharedService, private toastr: ToastrService) { }

  ngOnInit(): void {
    console.log('here');
    this.Id=this.section.Id;
    this.Name=this.section.Name;
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
      Name: this.Name
    }

    this.service.addSection(item).subscribe(res => {this.toastr.success("Item added succsessfuly", "Success")});
  }

  updateSection() {
    var item = {
      Id: this.Id,
      Name: this.Name
    }

    this.service.updateSection(item).subscribe(res => {this.toastr.success("Item updated succsessfuly", "Success")});
  }
}
