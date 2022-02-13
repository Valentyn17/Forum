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
  constructor(private serice: SharedService,
    private route: ActivatedRoute,
    private accountService: AccountService ) { }
  TopicId:any;
  MessageList : any=[];
  ModalTitle: string="";
  ActivateAddUpdateMessageComp: boolean=false;
  message:any={};
  userId:any;
  topic: any;


  ngOnInit(): void {
    this.refreshMessageList();
    this.message.TopicId=this.TopicId;
    this.message.UserId=this.userId
    this.topic=this.serice.gettopicById(this.TopicId);
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
       this.serice.deleteMessage(item.Id).subscribe(data=>{
         alert('Message with id '+data.toString()+" was deleted!!");
         this.refreshMessageList();
       });
     }
  }
  refreshMessageList(){
    this.TopicId = this.route.snapshot.paramMap.get('topicid');
    this.serice.getMessageList().subscribe(data=>{
      this.MessageList=data;
    });
  }
}
