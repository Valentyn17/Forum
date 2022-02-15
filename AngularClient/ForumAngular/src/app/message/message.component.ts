import { Component, Input, OnInit } from '@angular/core';
import { SharedService } from '../shared.service';
import { ActivatedRoute } from '@angular/router';
import { AccountService } from '../account.service';

@Component({
  selector: 'app-message',
  templateUrl: './message.component.html',
  styleUrls: ['./message.component.css']
})
export class MessageComponent implements OnInit {
  constructor(private service: SharedService,
    private route: ActivatedRoute,
    private accountService: AccountService ) { }
  TopicId:any;
  MessageList : any=[];
  ModalTitle: string="";
  ActivateAddUpdateMessageComp: boolean=false;
  message:any={};
  userId:any;
  topic:any;
  Ifadmin=false;
  messageOwner=false;
  
  ngOnInit(): void {
    this.Ifadmin=this.accountService.ifAdmin();
    
    this.TopicId = parseInt(this.route.snapshot.paramMap.get('topicid')as string);
    this.service.gettopicById(this.TopicId).subscribe(data=>{
      this.topic=data;
    });
    this.refreshMessageList();
    this.message.TopicId=this.TopicId;
    this.message.UserId=this.userId;
  }

  addClick(){
    this.message={
      Id:0,
      Text:"",

    }
    this.ModalTitle="Add Message";
    this.ActivateAddUpdateMessageComp=true;
  }

  editClick(item :any){
    this.message=item;
    this.ModalTitle="Edit Message";
    this.ActivateAddUpdateMessageComp=true;
  }

  closeClick(){
    this.ActivateAddUpdateMessageComp=false;
    this.refreshMessageList();
  }

  deleteClick(item: any)
  {
     if(confirm("Are you sure?")){
       this.service.deleteMessage(item.id).subscribe(data=>{
         alert("Message  was deleted!!");
         this.refreshMessageList();
       });
     }
  }
  refreshMessageList(){
    this.service.getMessageListByTopic(this.TopicId).subscribe(data=>{
      this.MessageList=data;
    });
  }
}
