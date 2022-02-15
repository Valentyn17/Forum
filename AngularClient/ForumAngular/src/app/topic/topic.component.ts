import { Component, OnInit } from '@angular/core';
import { SharedService } from '../shared.service';
import { ActivatedRoute } from '@angular/router';
import { AccountService } from '../account.service';


@Component({
  selector: 'app-topic',
  templateUrl: './topic.component.html',
  styleUrls: ['./topic.component.css']
})


export class TopicComponent implements OnInit {

  constructor(private serice: SharedService,
    private route: ActivatedRoute,
    private accountService: AccountService ) { }
  SectionId:any;
  Ifadmin=false;
  TopicList : any=[];
  ModalTitle: string="";
  ActivateAddUpdateTopicComp: boolean=false;
  topic: any={};
  userId:any;

  ngOnInit(): void {
    this.Ifadmin=this.accountService.ifAdmin();
    this.refreshTopicList();
    this.topic.SectionId=this.SectionId;
    this.topic.UserId=this.userId

  }

  addClick(){
    this.topic={
      Id:0,
      Name:"",

    }
    this.ModalTitle="Add Topic";
    this.ActivateAddUpdateTopicComp=true;
  }

  editClick(item :any){
    this.topic=item;
    this.ModalTitle="Edit Topic";
    this.ActivateAddUpdateTopicComp=true;
  }

  closeClick(){
    this.ActivateAddUpdateTopicComp=false;
    this.refreshTopicList();
  }

  deleteClick(item: any)
  {
     if(confirm("Are you sure?")){
       this.serice.deleteTopic(item.id).subscribe(data=>{
         alert("Topic  was deleted!!");
         this.refreshTopicList();
       });
     }
  }
  refreshTopicList(){
    this.SectionId = this.route.snapshot.paramMap.get('id');
    this.serice.getTopicListBySection(this.SectionId).subscribe(data=>{
      this.TopicList=data;
    });
  }
}
