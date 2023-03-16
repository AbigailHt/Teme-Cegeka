import type { Person } from "./Person";
import type { FundraiserStatus } from "./FundraiserStatus";

export class Fundraiser{
     title:string;
     description : string;
     owner : Person;
     dueDate : Date;
     status: FundraiserStatus;
     creationTime: Date;
     raisedAmount : Number;

     constructor(title:string, description:string,owner:Person, dueDate:Date,status:FundraiserStatus,creationTime: Date,raisedAmount:Number){
        this.title=title;
        this.description=description;
        this.owner=owner;
        this.dueDate=dueDate;
        this.status=status;
        this.creationTime=creationTime;
        this.raisedAmount=raisedAmount;
     }


}