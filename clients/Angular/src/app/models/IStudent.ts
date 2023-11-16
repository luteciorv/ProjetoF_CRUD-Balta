import { ISubscription } from "./ISubscription";

export interface IStudent {
    id: string;
    name: string;
    email: string;
    createdAt: string;

    subscriptions: ISubscription[];
}