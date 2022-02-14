import { Component,Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from 'src/app/account.service';
import { User } from 'src/app/models/User';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-update-message',
  templateUrl: './add-update-message.component.html',
  styleUrls: ['./add-update-message.component.css']
})
export class AddUpdateMessageComponent implements OnInit {
  @Input() message :any;
  Id: any;
  Text:string;
  TopicId:any;
  User: User;
  UserId: any;

  constructor(private service:SharedService, 
    private toastr: ToastrService,
    private route: ActivatedRoute,
    private accountService: AccountService) { }

  ngOnInit(): void {
    this.TopicId = this.route.snapshot.paramMap.get('topicid');
    this.Id=this.message.id;
    this.Text=this.message.text;
    this.User=this.accountService.getUser(localStorage.getItem('token') as string);
    this.UserId=this.User.id;
    
  }


  addMessage() {
      var item = {
      Text: this.Text,
      UserId: this.UserId,
      TopicId: this.TopicId
    }
    this.service.addMessage(item).subscribe(res => {this.toastr.success("Item added succsessfuly", "Success")});
  }

  updateMessage() {
    var item = {
      Id: this.Id,
      Text: this.Text,
      UserId: this.UserId,
      TopicId: this.TopicId
    }

    this.service.updateMessage(item).subscribe(res => {this.toastr.success("Item updated succsessfuly", "Success")});
  }
}
