import { Component, OnInit } from '@angular/core';
import { SharedService } from '../shared.service';
import { ActivatedRoute } from '@angular/router';
import { AccountService } from '../account.service';


@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  constructor(private serice: SharedService,
    private route: ActivatedRoute,
    private accountService: AccountService ) { }
  UserList : any=[];
  ModalTitle: string="";
  ActivateAddUpdateTopicComp: boolean=false;
  userId:any;

  ngOnInit(): void {
    this.refreshUserList();

  }

  deleteClick(item: any)
  {
     if(confirm("Are you sure?")){
       this.serice.deleteTopic(item.id).subscribe(data=>{
         alert("User was deleted!!");
         this.refreshUserList();
       });
     }
  }
  refreshUserList(){
    this.accountService.getUserList().subscribe(data=>{
      this.UserList=data;
    });
  }

}
