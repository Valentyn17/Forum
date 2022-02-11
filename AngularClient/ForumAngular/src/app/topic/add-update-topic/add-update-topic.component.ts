import { Component,Input, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from 'src/app/account.service';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-add-update-topic',
  templateUrl: './add-update-topic.component.html',
  styleUrls: ['./add-update-topic.component.css']
})
export class AddUpdateTopicComponent implements OnInit {
  @Input() topic :any;
  Id: any;
  Title:string;
  Description: string;
  SectionId:any;
  UserId:any;
  MessagesIds:any[];
  email: any;

  constructor(private service:SharedService, 
    private toastr: ToastrService,
    private route: ActivatedRoute,
    private accountService: AccountService) { }

  ngOnInit(): void {
    this.SectionId = this.route.snapshot.paramMap.get('id');
    console.log('here');
    this.Id=this.topic.Id;
    this.Title=this.topic.Name;
    this.Description=this.topic.Description;
    this.email=this.accountService.getUser(localStorage.getItem('token') as string).email;
    this.accountService.getUserByEmail(this.email).subscribe(data=>{this.UserId=data})
  }


  addTopic() {
      var item = {
      Title: this.Title,
      MessagesIds: this.MessagesIds,
      Description:this.Description,
      UserId: this.UserId,
      SectionId: this.SectionId
    }

    this.service.addTopic(item).subscribe(res => {this.toastr.success("Item added succsessfuly", "Success")});
  }

  updateTopic() {
    var item = {
      Id: this.Id,
      Title: this.Title,
      MessagesIds: this.MessagesIds,
      Description: this.Description,
      UserId: this.UserId,
      SectionId: this.SectionId
    }

    this.service.updateTopic(item).subscribe(res => {this.toastr.success("Item updated succsessfuly", "Success")});
  }

}
