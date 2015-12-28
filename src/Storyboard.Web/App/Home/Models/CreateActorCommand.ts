import {IActor} from './StoryModels';
import {ICreateLinkForNewNodeCommand} from './LinkModels';

export interface ICreateActorCommand {
    ActorCommand: IActor;
    Links: ICreateLinkForNewNodeCommand[];
}