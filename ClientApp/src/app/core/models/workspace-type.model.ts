import { Workspace } from "./workspace.model";

export class WorkspaceType{
    constructor(
        public id: number, 
        public name: string,
        public description: string,
        public imageUrl: string,
        public amenities: string[],
        public workspaces: Workspace[]
    ){}
}