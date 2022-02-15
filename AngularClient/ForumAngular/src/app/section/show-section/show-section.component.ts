import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/account.service';
import { SharedService } from 'src/app/shared.service';
@Component({
  selector: 'app-show-section',
  templateUrl: './show-section.component.html',
  styleUrls: ['./show-section.component.css']
})
export class ShowSectionComponent implements OnInit {

  constructor(private serice: SharedService, private accountService: AccountService) { }
  Ifadmin=false;
  SectionList : any=[];
  ModalTitle: string="";
  ActivateAddUpdateSectionComp: boolean=false;
  section:any;
  

  ngOnInit(): void {
    this.Ifadmin=this.accountService.ifAdmin();
    this.refreshSectionList();
  }

  addClick(){
    this.section={
      Id:0,
      Name:""
    }
    this.ModalTitle="Add Section";
    this.ActivateAddUpdateSectionComp=true;
  }

  editClick(item :any){
    this.section=item;
    this.ModalTitle="Edit Section";
    this.ActivateAddUpdateSectionComp=true;
  }

  closeClick(){
    this.ActivateAddUpdateSectionComp=false;
    this.refreshSectionList();
  }

  deleteClick(item: any)
  {
     if(confirm("Are you sure?")){
       this.serice.deleteSection(item.id).subscribe(data=>{
         alert("Section  was deleted!!");
         this.refreshSectionList();
       });
     }
  }
  refreshSectionList(){
    this.serice.getSectionList().subscribe(data=>{
      this.SectionList=data;
    });
  }
}
