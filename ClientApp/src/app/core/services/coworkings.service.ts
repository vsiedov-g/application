import { HttpClient} from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { API_ENDPOINTS } from "../constants/api-endpoints";
import { Coworking } from "../models/coworking.model";
import { WorkspaceType } from "../models/workspace-type.model";



@Injectable({providedIn: 'root'})
export class CoworkingService {
    private http = inject(HttpClient)
    getAll(){
        return this.http.get<Coworking[]>(API_ENDPOINTS.COWORKING);
    }
    GetAllCoworkingWorkspaceTypes(coworkingId: number){
        return this.http.get<WorkspaceType[]>(`${API_ENDPOINTS.COWORKING}/${coworkingId}/workspaceTypes`);
    }
} 