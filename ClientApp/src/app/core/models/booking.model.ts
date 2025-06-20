import { WorkspaceType } from "./workspace-type.model";
export class BookingRequest{
    constructor(
        public id: number, 
        public userName: string,
        public userEmail: string,
        public capacity: number,
        public startDate: string,
        public endDate: string,
        public startTime: string,
        public endTime: string,
        public workspaceTypeId: number,
        public coworkingId: number,
    ){}
}

export class BookingResponse{
    constructor(
        public id: number, 
        public userName: string,
        public userEmail: string,
        public capacity: number,
        public startDate: string,
        public endDate: string,
        public startTime: string,
        public endTime: string,
        public workspaceType: WorkspaceType,
        public coworkingId: number,
        public coworking: string,
    ){}
}