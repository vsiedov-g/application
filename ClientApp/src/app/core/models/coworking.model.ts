export class Coworking{
    constructor(
        public id: number, 
        public name: string,
        public description: string,
        public address: string,
        public availability: CoworkingAvailability[],
        public imageUrl: string
    ){}
}

class CoworkingAvailability{
    constructor(
        public workspaceType: string, 
        public workspaceCount: number
    ){}
 }