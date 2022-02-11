import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
@Component({
  selector: 'app-show-section',
  templateUrl: './show-section.component.html',
  styleUrls: ['./show-section.component.css']
})
export class ShowSectionComponent implements OnInit {

  constructor(private serice: SharedService) { }

  SectionList : any=[];
  ModalTitle: string="";
  ActivateAddUpdateSectionComp: boolean=false;
  section:any;
  

  ngOnInit(): void {
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
       this.serice.deleteSection(item.Id).subscribe(data=>{
         alert('Section with id '+data.toString()+" was deleted!!");
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
