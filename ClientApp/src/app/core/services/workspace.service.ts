import { HttpClient, HttpParams } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { API_ENDPOINTS } from "../constants/api-endpoints";
import { Workspace } from "../models/workspace.model";



@Injectable({providedIn: 'root'})
export class WorkspaceService {
    private http = inject(HttpClient)
    getAll(workspaceTypeId?: number){
        if(workspaceTypeId){
            return this.http.get<Workspace[]>(API_ENDPOINTS.WORKSPACE, {params: new HttpParams().set('workspaceTypeId', workspaceTypeId)});
        }
        return this.http.get<Workspace[]>(API_ENDPOINTS.WORKSPACE);  
    }
    getById(Id: number){
        return this.http.get<Workspace>(`${API_ENDPOINTS.WORKSPACE}/${Id}`);
    }
}