import { HttpClient, HttpParams } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { API_ENDPOINTS } from "../constants/api-endpoints";
import { WorkspaceType } from "../models/workspace-type.model";



@Injectable({providedIn: 'root'})
export class WorkspaceTypeService {
    private http = inject(HttpClient)
    getAll(includeDetails: boolean = false){
        return this.http.get<WorkspaceType[]>(API_ENDPOINTS.WORKSPACE_TYPE, {params: new HttpParams().set('includeDetails', includeDetails.toString())});
    }
    getById(Id: number){
        return this.http.get<WorkspaceType>(`${API_ENDPOINTS.WORKSPACE_TYPE}/${Id}`);
    }
}