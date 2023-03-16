import axios from "axios";
import { Person } from "src/models/Person";
import { Fundraiser } from "src/models/Fundraiser";
import { FundraiserStatus } from "src/models/FundraiserStatus";

export class FundraiserService{
    private apiUrl:string="https://localhost:7075";

    public getAll():Promise<Fundraiser[]>{
        return axios
        .get(this.apiUrl+'/Fundraisers')
        .then(response=>{
            console.log(response.data);

            var fundraisersResponse: Fundraiser[]=[];
            response.data.forEach((fundraiserFromApi: IdentifiableFundraiserDto)=>{
                let owner=new Person(fundraiserFromApi.owner.name,fundraiserFromApi.owner.id);
                
                fundraisersResponse.push(
                    new Fundraiser(fundraiserFromApi.title, fundraiserFromApi.description,owner,fundraiserFromApi.dueDate,fundraiserFromApi.status,fundraiserFromApi.creationTime,fundraiserFromApi.raisedAmount)
                )
            });
            
            return fundraisersResponse;
        })
    }

    // Get information about a specific fundraiser
    public get(id: number): Promise<Fundraiser> {
        return axios.get(`${this.apiUrl}/Fundraisers/${id}`)
          .then(response => {
            const fundraiserFromApi: IdentifiableFundraiserDto = response.data;
            let owner=new Person(fundraiserFromApi.owner.name,fundraiserFromApi.owner.id);
  
            return new Fundraiser(
                fundraiserFromApi.title, fundraiserFromApi.description,owner,fundraiserFromApi.dueDate,fundraiserFromApi.status,fundraiserFromApi.creationTime,fundraiserFromApi.raisedAmount)
          })
    }

    // Create a fundraiser
    public create(
        id:Number,
        title:string,
        description : string,
        owner : Person,
        dueDate : Date,
        status: FundraiserStatus,
        creationTime: Date,
        raisedAmount : Number
      ): Promise<Fundraiser> {
        const newFundraiser: IdentifiableFundraiserDto = {
           id:id,
           title:title,
           description:description,
           owner:new Person(owner.name,owner.id),
           dueDate:dueDate,
           status:FundraiserStatus.Active,
           creationTime:new Date(),
           raisedAmount:0
        }
  
        return axios.post(`${this.apiUrl}/Fundraisers`, newFundraiser)
          .then(response => {
            const createdFundraiser: IdentifiableFundraiserDto = response.data;
            let owner=new Person(createdFundraiser.owner.name,createdFundraiser.owner.id);
  
            return new Fundraiser(createdFundraiser.title,createdFundraiser.description,createdFundraiser.owner,createdFundraiser.dueDate,createdFundraiser.status,createdFundraiser.creationTime,createdFundraiser.raisedAmount
            )
          })
    }

    // Delete a fundraiser
    public delete(id: number): Promise<void> {
        return axios.delete(`${this.apiUrl}/Fundraisers/${id}`)
    }

    public donateToFundraiser(fundraiserId: number, donor: Person, amount: number): Promise<void>{
        return axios
        .post(`${this.apiUrl}/Fundraisers/${fundraiserId}/donate`, {
            donor,
            amount
        })
        .then(response=>{
            console.log(response.data);
        })
    }
}

interface FundraiserDTO{
     description : string;
     dueDate : Date;
     status: FundraiserStatus;
     creationTime: Date;
     raisedAmount : Number;
}

interface IdentifiableFundraiserDto extends FundraiserDTO{
    id:Number;
    owner:PersonDto;
    title:string;
}

interface PersonDto
{
    name: string;
    id: string; 
}